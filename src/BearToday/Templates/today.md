---
title: "{{date.day}} {{date.month_name}} {{date.year}}"
tags: ["today/{{date.year}}/{{date.padded_month}}"]

---
## Journal


## Top Three Things To Do Today

{% for i in (1..3) %}
   - [ ] Thing {{ i }}{% endfor %}

## Log

{{date.day_of_week}}

