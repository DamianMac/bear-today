---
title: "{{date.day}} {{date.month_name}} {{date.year}}"
tags: ["journal/{{date.year}}/{{date.padded_month}}"]
pin: true
showtimestamp: false
---
## Journal


## Top Three Things To Do {{date.day_of_week}}

{% for i in (1..3) %}
   - [ ] Thing {{ i }}{% endfor %}

## Log

Ends



